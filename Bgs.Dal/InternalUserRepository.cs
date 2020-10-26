using Bgs.Common.Entities;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;

namespace Bgs.Dal
{
    public class InternalUserRepository : SqlServerRepository, IInternalUserRepository
    {
        private const string _schemaInternalUser = "InternalUser";

        public InternalUserRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }

        public InternalUser GetUserByCredentials(string email, string password)
        {
            using (var cmd = GetSpCommand($"{_schemaInternalUser}.GetUserByCredentials"))
            {
                cmd.AddParameter("Email", email);
                cmd.AddParameter("Password", password);

                return cmd.ExecuteReaderSingleClosed<InternalUser>();
            }
        }
    }
}
