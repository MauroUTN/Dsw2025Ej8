using System;
using Dsw2025Ej8.Exceptions;


namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, titulares) { }

        public override void Depositar(decimal monto)
        {
            if (Estado != Estado.Activa)
                throw new CuentaNoActivaException(Estado);

            if (monto <= 0)
                throw new MontoNoValidoException();

            _saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (Estado != Estado.Activa)
                throw new CuentaNoActivaException(Estado);

            if (monto <= 0)
                throw new MontoNoValidoException();

            if (Saldo < monto)
            {
                _estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
            }

            _saldo -= monto;
        }

        public override void AplicarInteres()
        {
            if (Estado != Estado.Activa)
                throw new CuentaNoActivaException(Estado);

            _saldo += Saldo * TasaDeInteres;
        }
    }
}
