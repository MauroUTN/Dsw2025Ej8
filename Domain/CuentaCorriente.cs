using System;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public CuentaCorriente(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, titulares) { }

        public override void Depositar(decimal monto)
        {
            if (Estado != Estado.Activa)
                throw new CuentaNoActivaException(Estado);

            if (monto <= 0)
                throw new MontoNoValidoException();

            monto -= monto * _comision;
            _saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (Estado != Estado.Activa)
                throw new CuentaNoActivaException(Estado);

            if (monto <= 0)
                throw new MontoNoValidoException();

            if (_saldo - monto < -_limiteDeDescubierto)
            {
                _estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
            }

            _saldo -= monto;

            if (_saldo < 0)
                _estado = Estado.Suspendida;
        }

        public override void AplicarInteres()
        {
            if (Estado != Estado.Activa)
                throw new CuentaNoActivaException(Estado);

            // No aplica interés en cuenta corriente
        }
    }
}

