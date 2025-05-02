namespace Dsw2025Ej8;
using System;
using System.Collections.Generic;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;
using System.Text;
using System.Globalization;
using System.Threading;


internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-AR");

        // 1) Instanciar y configurar cuentas
        var cuentas = new List<CuentaBancaria>
        {
            new CajaDeAhorro("001", 1000, new[] { "Mauro" }) { TasaDeInteres = 0.05m },
            new CajaDeAhorro("002", 500,  new[] { "Ana"   }) { TasaDeInteres = 0.03m },
            new CuentaCorriente("003", 1000, new[] { "Luis"  }) { Comision = 0.02m, LimiteDeDescubierto = 300 },
            new CuentaCorriente("004", 200,  new[] { "Laura" }) { Comision = 0.01m, LimiteDeDescubierto = 500 }
        };

        // 2) Ejecutar operaciones sobre cada cuenta
        foreach (var cuenta in cuentas)
        {
            try
            {
                cuenta.Depositar(500);
                cuenta.Retirar(200);
                cuenta.Retirar(2000);  // Forzar excepción si corresponde
                cuenta.AplicarInteres();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cuenta {cuenta.Numero}: {ex.Message}");
            }
        }

        // 3) bloque que recorre las 4 cuentas
        Console.WriteLine("\nResumen de cuentas:");
        foreach (var cuenta in cuentas)
        {
            var resumen = new
            {
                Numero = cuenta.Numero,
                Tipo = cuenta.GetType().Name,
                Saldo = cuenta.Saldo
            };

            Console.WriteLine(
                $"Cuenta: {resumen.Numero}, " +
                $"Tipo: {resumen.Tipo}, " +
                $"Saldo: {resumen.Saldo:C}");
        }

        
    }
}


