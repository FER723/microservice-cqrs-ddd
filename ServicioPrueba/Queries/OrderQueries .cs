using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Dynamic;
using System.Collections.Generic;

public class OrderQueries : IOrderQueries
{
    //public async Task<IEnumerable<OrderSummary>> GetOrdersAsync()
    //{
    //    using (var connection = new SqlConnection(_connectionString))
    //    {
    //        connection.Open();
    //        return await connection.QueryAsync<OrderSummary>(
    //              @"SELECT o.[Id] as ordernumber,
    //              o.[OrderDate] as [date],os.[Name] as [status],
    //              SUM(oi.units*oi.unitprice) as total
    //              FROM [ordering].[Orders] o
    //              LEFT JOIN[ordering].[orderitems] oi ON  o.Id = oi.orderid
    //              LEFT JOIN[ordering].[orderstatus] os on o.OrderStatusId = os.Id
    //              GROUP BY o.[Id], o.[OrderDate], os.[Name]
    //              ORDER BY o.[Id]");
    //    }
    //}
}