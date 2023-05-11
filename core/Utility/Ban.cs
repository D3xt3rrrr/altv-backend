using gamemode.core.Database;
using Npgsql;

namespace gamemode.Player;

public class Ban
{
    private Accounts _accounts;
    
    public Ban(Accounts accounts)
    {
        this._accounts = accounts;
    }


    public bool verify()
    {
        return true;
    }

    public bool BanAccount(MyPlayer adminPlayer, MyPlayer playerToBan)
    {
        if (adminPlayer.Account.isAdmin())
        {
            List<Accounts> accountList = Postgresql.FetchAll<Accounts>("SELECT * from account_ban where id=@id",
                new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@id", adminPlayer.Account.Id)
                });

            if (accountList.Count == 0)
            {


                Postgresql.Execute("INSERT INTO account_ban (account_id, ip) VALUES (@account_id, @ip)",
                    new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@id", playerToBan.AccountId),
                        new NpgsqlParameter("@ip", playerToBan.Ip),
                    });
                return true;
            }
        }

        return false;
    }
}