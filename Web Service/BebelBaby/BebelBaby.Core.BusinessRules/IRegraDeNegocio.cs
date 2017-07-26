namespace BebelBaby.Core.BusinessRules
{
    public interface IRegraDeNegocio
    {
        string MensagemDeErro { get; }
    }

    public interface IRegraDeNegocio<in TEntidade> : IRegraDeNegocio
    {
        bool EhSatisfeitaPor(TEntidade entidade);
    }

    public interface IRegraDeNegocio<in TEntidade, in TGeneric> : IRegraDeNegocio
    {
        bool EhSatisfeitaPor(TEntidade entidade, TGeneric generic);
    }
}