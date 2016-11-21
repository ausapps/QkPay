using System;
using SQLite;
using SQLite.Net;

namespace QkPay.Data
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

