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
    public class PersonBusinessObject
    {
        private PersonDataAccessObject _dao;
        public PersonBusinessObject()
        {
            _dao = new PersonDataAccessObject();
        }

        private TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region List
        public OperationResult<List<Person>> List()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.List();
                    ts.Complete();
                    return new OperationResult<List<Person>>() { Success = true, Result = result };
                }


            }
            catch (Exception e)
            {
                return new OperationResult<List<Person>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Person>>> ListAsync()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<List<Person>>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<Person>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(Person item)
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

        public async Task<OperationResult> CreateAsync(Person item)
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
        public OperationResult<Person> Read(Guid id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    ts.Complete();
                    return new OperationResult<Person>() { Success = true, Result = res };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<Person>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Person>> ReadAsync(Guid id)
        {
            try
            {
                using var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ReadAsync(id);
                ts.Complete();
                return new OperationResult<Person>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<Person>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Person item)
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

        public async Task<OperationResult> UpdateAsync(Person item)
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
        public OperationResult Delete(Person item)
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

        public async Task<OperationResult> DeleteAsync(Person item)
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
