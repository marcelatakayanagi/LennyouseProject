using Microsoft.Win32.SafeHandles;
using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfoBO
{
    public class StaffRecordBusinessObject
    {
        private StaffRecordDataAccessObject _dao;

        public StaffRecordBusinessObject()
        {
            _dao = new StaffRecordDataAccessObject();
        }

        private TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region List
        public OperationResult<List<StaffRecord>> List()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.List();
                    ts.Complete();
                    return new OperationResult<List<StaffRecord>>() { Success = true, Result = result };
                }


            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffRecord>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<StaffRecord>>> ListAsync()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<List<StaffRecord>>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffRecord>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(StaffRecord item)
        {
            try
            {
                _dao.Create(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> CreateAsync(StaffRecord item)
        {
            try
            {
                await _dao.CreateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        #endregion

        #region Read
        public OperationResult<StaffRecord> Read(Guid id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    ts.Complete();
                    return new OperationResult<StaffRecord>() { Success = true, Result = res };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<StaffRecord>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<StaffRecord>> ReadAsync(Guid id)
        {
            try
            {
                using var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ReadAsync(id);
                ts.Complete();
                return new OperationResult<StaffRecord>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<StaffRecord>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(StaffRecord item)
        {
            try
            {
                _dao.Update(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> UpdateAsync(StaffRecord item)
        {
            try
            {
                await _dao.UpdateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(StaffRecord item)
        {
            try
            {
                _dao.Delete(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> DeleteAsync(StaffRecord item)
        {
            try
            {
                await _dao.DeleteAsync(item);
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

                _dao.Delete(id);

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
                await _dao.DeleteAsync(id);
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
