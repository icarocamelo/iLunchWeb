using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Context;
using iLunch.Repository.Infrastructure;

namespace iLunchWeb.Infrastructure
{
    public class SessionLifeCycle : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.EndRequest += ContextEndRequest;
        }

        public void Dispose()
        {
        }

        #endregion

        private static void ContextEndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionProvider.Factory);

            if (session == null)
                return;

            try
            {
                session.Flush();
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();

                throw;
            }
            finally
            {
                session.Close();
            }
        }
    }
}