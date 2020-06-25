using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects
{
    public class RestaurantBusinessObject
    {
        private RestaurantDataAccessObject _dao;
        public RestaurantBusinessObject()
        {
            _dao = new RestaurantDataAccessObject();
        }

        #region Create
        public OperationResult Create(Restaurant item)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required,transactionOptions,TransactionScopeAsyncFlowOption.Enabled);
                _dao.Create(item);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch(Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
            
        }
        //public async Task<OperationResult> CreateAsync(Restaurant item)
        //{
        //    await _dao.CreateAsync(item);
        //}
        #endregion



        #region Read
        public OperationResult<Restaurant> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var res= _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Restaurant> { Success = true, Result=res };
            }
            catch (Exception e)
            {
                return new OperationResult<Restaurant> { Success = false, Exception = e };
            }
        }
        #endregion



        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
