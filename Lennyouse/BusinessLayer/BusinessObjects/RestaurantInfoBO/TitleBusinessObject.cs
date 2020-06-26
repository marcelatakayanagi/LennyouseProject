using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfoBO
{
    public class TitleBusinessObject
    {
        private TitleDataAccessObject _dao;
        public TitleBusinessObject()
        {
            _dao = new TitleDataAccessObject();
        }

        #region List
        public OperationResult<List<Title>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var res = _dao.List();
                transactionScope.Complete();
                return new OperationResult<List<Title>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Title>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Title>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<Title>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Title>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(Title item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                _dao.Create(item);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> CreateAsync(Title item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.CreateAsync(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Title> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Title>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<Title>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Title>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Title>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<Title>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Title item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                _dao.Update(item);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> UpdateAsync(Title item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.UpdateAsync(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Title item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                _dao.Delete(item);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> DeleteAsync(Title item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.DeleteAsync(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public OperationResult Delete(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                _dao.Delete(id);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.DeleteAsync(id);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion
    }
}
