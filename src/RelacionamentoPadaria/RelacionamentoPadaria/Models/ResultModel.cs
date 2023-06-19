using RelacionamentoPadaria.Enums;

namespace RelacionamentoPadaria.Models
{
    public class ResultModel<T> where T : class
    {
        public T Model { get; set; } = (T)Activator.CreateInstance(typeof(T));
        public StatusEnum Status { get; set; }
        public string Mensagem { get; set; } = String.Empty;
    }
}
