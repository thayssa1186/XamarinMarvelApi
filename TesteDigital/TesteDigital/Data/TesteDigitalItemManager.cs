
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TesteDigital
{
    public class TesteDigitalItemManager
    {
        IRestService restService;

        public TesteDigitalItemManager(IRestService service)
        {
            restService = service;
        }

        public async Task<List<Personagem>> GetTasksAsync()
        {
            var sync = await App.Database.GetSincronizacaoAsync();
            var result = new List<Personagem>();

            if(sync == null)
            {
                try
                {
                    result = await restService.RefreshDataAsync();

                    await App.Database.DropTablePersonagemAsync();
                    await App.Database.DropTableFasciculosAsync(); 

                    await App.Database.CreateTable();

                    foreach (var personagem in result)
                    {
                        try
                        {
                            await App.Database.SavePersonagemAsync(SetPersonagemEN(personagem));

                            foreach (var fasciculos in personagem.Fasciculos)
                            {
                                try
                                {
                                    await App.Database.SaveFasciculosAsync(SetFasciculosEN(fasciculos));
                                }
                                catch (Exception ex)
                                {
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

                    return await GetPersonagem(true);
                }
                catch (Exception ex)
                {
                    return result;
                }
            }
            else if (sync.data.AddMinutes(5) <= DateTime.Now)
            {
                try
                {
                    result = await restService.RefreshDataAsync();
                }
                catch(Exception ex)
                {
                    return await GetPersonagem();
                }

                await App.Database.DropTablePersonagemAsync();
                await App.Database.DropTableFasciculosAsync();

                await App.Database.CreateTable();
                foreach (var personagem in result)
                {
                    try
                    {
                        await App.Database.SavePersonagemAsync(SetPersonagemEN(personagem));

                        foreach (var fasciculos in personagem.Fasciculos)
                        {
                            try
                            {
                                await App.Database.SaveFasciculosAsync(SetFasciculosEN(fasciculos));
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                return await GetPersonagem(true);
            }
            else
            {
                return await GetPersonagem();
            }
        }

        private async Task<List<Personagem>> GetPersonagem(bool isSync = false)
        {
            var Listp = new List<Personagem>();

            try
            {
               
                var Listper = await App.Database.GetPersonagensAsync();

                foreach (var pen in Listper)
                {
                    var p = new Personagem();
                    p.description = pen.description;
                    p.id = pen.id;
                    p.ImageURL = pen.ImageURL;
                    p.name = pen.name;
                    p.Fasciculos = await GetFasciculos(pen.id);

                    Listp.Add(p);

                    
                }

                if (isSync)
                {
                    await App.Database.SaveDataSync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Listp;

        }

        private async Task<List<Fasciculo>> GetFasciculos(string idpersonagem)
        {
            var Listf = new List<Fasciculo>();

            var tempList = await App.Database.GetFasciculosAsync();
            var Listfas = tempList.FindAll(i => i.idPersonagem == idpersonagem);

            foreach (var fas in Listfas)
            {
                var f = new Fasciculo();
                f.id = fas.id;
                f.idPersonagem = fas.idPersonagem;
                f.ImageURL = fas.ImageURL;
                f.name = fas.name;

                Listf.Add(f);

            }

            return Listf;

        }

        private PersonagemEN SetPersonagemEN(Personagem pen)
        {
            var p = new PersonagemEN();
            p.id = pen.id;
            p.ImageURL = pen.ImageURL;
            p.name = pen.name;
            p.description = pen.description;

            return p;
        }

        private FasciculoEN SetFasciculosEN(Fasciculo fas)
        {
            var f = new FasciculoEN();
            f.id = fas.id;
            f.idPersonagem = fas.idPersonagem;
            f.ImageURL = fas.ImageURL;
            f.name = fas.name;
          

            return f;
        }

    }
}
