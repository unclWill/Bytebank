/* Struct  : ClientDataFormat
 * Objetivo: Contém métodos que facilitam a exibição da formatação dos dados do cliente (AccountHolder).
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 30/06/2023 (Criação) | Modificação: 30/07/2023
 */

namespace Bytebank.Clients.Extensions;
internal struct ClientDataFormat
{
    /// <summary>
    /// Realiza a formatação do Cpf do cliente para que possa ser exibido na forma usual que consta nos decumentos.
    /// </summary>
    /// <param name="cpfNumber">Recebe a string que representa o número do Cpf do cliente.</param>
    /// <returns>Retorna a string formatada como 000.000.000-00</returns>
    /// <exception cref="ArgumentException">Lança uma exceção que informa que o argumento passado deve ter 11 caracteres.</exception>
    internal static string CpfFormat(string cpfNumber)
    {
        if (cpfNumber.Length != 11) throw new ArgumentException($"[!] Erro: O tamanho da string deve ser 11.", nameof(cpfNumber));
        {
            ReadOnlySpan<char> span = stackalloc char[cpfNumber.Length];
            span = cpfNumber.AsSpan();
            //var offset = 14 - cpfNumber.Length;
            return $"{span[0..3]}.{span[0..3]}.{span[0..3]}-{span[0..2]}";
        }
    }
}