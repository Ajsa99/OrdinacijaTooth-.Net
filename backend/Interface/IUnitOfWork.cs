namespace backend.Interface
{
    public interface IUnitOfWork
    {
        IKorisnikInterface KorisnikRepository { get; }
        IPacijentInterface PacijentRepository { get; }
        ITerminInterface TerminRepository { get; }
        IPregledInterface PregledRepository { get; }
        Task<bool> SaveAsync();
    }
}
