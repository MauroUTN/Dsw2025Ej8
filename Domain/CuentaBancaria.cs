namespace Dsw2025Ej8.Domain
{
    public abstract class CuentaBancaria
    {
        // Campos protegidos (solo accesibles desde esta clase y las que heredan)
        protected decimal _saldo;
        protected Estado _estado;
        protected decimal _tasaDeInteres;
        protected decimal _limiteDeDescubierto;
        protected decimal _comision;

        // Propiedades públicas
        public string Numero { get; private set; }

        public decimal Saldo => _saldo;

        public Estado Estado => _estado;

        public decimal TasaDeInteres
        {
            get => _tasaDeInteres;
            set => _tasaDeInteres = value;
        }

        public decimal LimiteDeDescubierto
        {
            get => _limiteDeDescubierto;
            set => _limiteDeDescubierto = value;
        }

        public decimal Comision
        {
            get => _comision;
            set => _comision = value;
        }

        public string[] Titulares { get; private set; }

        // Constructor
        protected CuentaBancaria(string numero, decimal saldo, string[] titulares)
        {
            Numero = numero;
            _saldo = saldo;
            _estado = Estado.Activa;
            Titulares = titulares;
        }

        // Métodos abstractos para que las subclases los implementen
        public abstract void Depositar(decimal monto);
        public abstract void Retirar(decimal monto);
        public abstract void AplicarInteres();
    }
}


