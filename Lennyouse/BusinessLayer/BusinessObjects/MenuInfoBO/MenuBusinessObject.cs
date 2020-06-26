using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO
{
    public class MenuBusinessObject
    {
        private MenuDataAccessObject _dao;
        public MenuBusinessObject()
        {
            _dao = new MenuDataAccessObject();
        }

        private TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region Create
        public OperationResult Create(Menu item)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                _dao.Create(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> CreateAsync(Menu item)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
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
        public OperationResult<Menu> Read(Guid id)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                var res = _dao.Read(id);
                scope.Complete();
                return new OperationResult<Menu>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<Menu>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Menu>> ReadAsync(Guid id)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ReadAsync(id);
                scope.Complete();
                return new OperationResult<Menu>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<Menu>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Menu item)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                _dao.Update(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> UpdateAsync(Menu item)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
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
        public OperationResult Delete(Menu item)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                _dao.Delete(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> DeleteAsync(Menu item)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
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
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                _dao.Delete(id);
                scope.Complete();
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
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
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

        #region List
        public OperationResult<List<Menu>> List()
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                var res = _dao.List();
                scope.Complete();
                return new OperationResult<List<Menu>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Menu>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Menu>>> ListAsync()
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                scope.Complete();
                return new OperationResult<List<Menu>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Menu>>() { Success = false, Exception = e };
            }
        }
        #endregion
    }
}
