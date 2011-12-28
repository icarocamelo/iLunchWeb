
using NHibernate;
using NHibernate.Context;

namespace iLunch.Repository.Infrastructure
{
    public static class SessionProvider
    {
        static SessionProvider()
        {
            Factory = FluentConfigurator.Instance.BuildSessionFactory();
        }

        public static ISessionFactory Factory { get; private set; }

        public static ISession CurrentSession
        {
            get
            {
                if (CurrentSessionContext.HasBind(Factory))
                    return Factory.GetCurrentSession();

                var session = Factory.OpenSession();

                CurrentSessionContext.Bind(session);
                session.BeginTransaction();

                return session;
            }
        }
    }
}
