using DAL.Context;
using Services.Interfaces;
using Services.JoinTables;
using System;

namespace Services.Repositories
{
    public class UOW : IUOW
    {
        private  readonly IJoinTables _joinTables;
        private ConstructionWasteDBContext Context;
        private IClientRepository _client;
        private ICarRepository _car;
        private ICarDriverRepository _carDriver;

        public UOW(ConstructionWasteDBContext Context, IJoinTables joinTables)
        {
            _joinTables = joinTables;
            this.Context = Context;
        }

        public IClientRepository Client
        {
            get
            {
                if (_client == null)
                  _client = new ClientRepository(Context, _joinTables);              
                return _client;
            }
        }

        public ICarRepository Car
        {
            get
            {
                if (_car == null)
                    _car = new CarRepository(Context,_joinTables);
                return _car;
            }
        }

        public ICarDriverRepository CarDriver 
        {
            get
            {
                if (_carDriver == null)
                    _carDriver = new CarDriverRepository(Context);
                return _carDriver;
            }
        }
        

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
