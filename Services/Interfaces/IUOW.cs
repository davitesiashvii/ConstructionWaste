using System;


namespace Services.Interfaces
{
    public interface IUOW : IDisposable
    {
        IClientRepository Client { get; }

        ICarRepository Car { get; }

        ICarDriverRepository CarDriver { get; }

        void Commit();
    }
}
