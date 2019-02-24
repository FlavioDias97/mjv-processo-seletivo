using System;
using System.Collections.Generic;
using MarketplaceAPI.Model;

namespace MarketplaceAPI.Services.Implementattions
{
    public class StoreServiceImpl : IStoreService
    {
        public Store Create(Store store)
        {
            return store;
        }

        public void Delete(long id)
        {
            //throw new NotImplementedException();
        }

        public List<Store> FindAll()
        {
            List<Store> stores = new List<Store>();
            for(int i = 0; i < 8; i++)
            {
                Store store = MockStore(i);
                stores.Add(store);
            }
            return stores;
        }

        private Store MockStore(int i)
        {
            return new Store
            {
                Id = 1,
                FantasyName = "Nome Fantasia",
                Cnpj = "1",
                CorporateName = "Nome corporativo",
                Address = "Endereço",
                Phone = "Telefone",
                Responsible = "Responsável"

            };
        }


        public Store FindById(long id)
        {
            return new Store {
                    Id = 1,
                    FantasyName = "Nome Fantasia",
                    Cnpj = "1",
                    CorporateName = "Nome corporativo",
                    Address = "Endereço",
                    Phone = "Telefone",
                    Responsible = "Responsável"

                };
        }

        public Store Update(Store store)
        {
            return store;
        }
    }
}
