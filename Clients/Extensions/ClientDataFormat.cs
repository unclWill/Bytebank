/* Struct  : ClientDataFormat
 * Objetivo: Contém métodos que facilitam a exibição da formatação dos dados do cliente (AccountHolder).
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 30/06/2023 (Criação) | Modificação: 30/07/2023
 */

using System.Linq.Expressions;

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
        try
        {
            ReadOnlySpan<char> span = stackalloc char[cpfNumber.Length];
            span = cpfNumber.AsSpan();
            return $"{span[0..3]}.{span[3..6]}.{span[6..9]}-{span[9..11]}";
        }
        catch (Exception)
        {
            throw new ArgumentException($"[!] Erro: O tamanho da string deve ser 11.", nameof(cpfNumber));
        }
    }
}