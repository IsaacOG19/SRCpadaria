namespace RelacionamentoPadaria.Models
{
    public abstract class BaseModel
    {
        public List<ValidacaoModel> Validacoes { get; set; } = new List<ValidacaoModel>();

        public abstract void Validar();
    }
}
