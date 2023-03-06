namespace EntityFramework.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }

        public Funcionario()
        {
            
        }

        public override string ToString()
        {
            return $"O produto é do id {Id}, que possui nome {Nome} e idade {Idade}";
        }
    }
}