using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class ServiceGNB : IServiceGNB
{
   
    private readonly ITransactionsService _transactionService;
    private readonly IRatesService _rateService;

    public ServiceGNB(ITransactionsService transactionService, IRatesService rateService)
    {
        _transactionService = transactionService;
        _rateService = rateService;

    }

   /// <summary>
   /// 
   /// </summary>
   /// <returns></returns>
    public async Task<IList<TransactionDTO>> GetTransactions()
    {
        var result  = new List<TransactionDTO>();
        try
        {
            var allTransactions = await _transactionService.GetTransactions();

            if(allTransactions)
                result.AddRange(allTransactions);
            else
            {
                throw new Exception("No Transactions");
            }


        }
        catch (Exception ex)
        {

            Log.Error(ex.Message);
        }
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IList<TransactionDTO>> GetRates()
    {
        var result = new List<TransactionDTO>();
        try
        {
            var allTransactions = await _rateService.GetRates();

            if (allTransactions)
                result.AddRange(allTransactions);
            else
            {
                throw new Exception("No Rates");
            }
        }
        catch (Exception ex)
        {

            Log.Error(ex.Message);
        }
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sku"></param>
    /// <returns></returns>
    public async Task<IList<TransactionDTO>> GetTransactionById(string sku)
    {
        var result = new List<TransactionDTO>();
        try
        {
            var allTransactions = await _transactionService.GetById(sku);

            if (allTransactions)
                result.AddRange(allTransactions);
            else
            {
                throw new Exception("No Transactions");
            }


        }
        catch (Exception ex)
        {

            Log.Error(ex.Message);
        }
        return result;
    }

}
