using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IServiceGNB
{
	/// <summary>
	/// Obtener el listado de todas las transacciones
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	[OperationContract]
	Task<IList<TransactionDTO>> GetTransactions();

	/// <summary>
	/// Obtener todos los rates
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	[OperationContract]
	Task<IList<TransactionDTO>> GetRates();

	/// <summary>
	/// Obtener un listado con todas las transacciones de ese producto en EUR, y la suma total de todas esas transacciones, también en EUR atraves de un sku
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	[OperationContract]
	Task<IList<TransactionDTO>> GetTransactionById( string sku);

	}
