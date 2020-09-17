using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using ServicioPrueba.Application.Configuration.Data;

namespace ServicioPrueba.Application.Atributos.GetAtributos
{
    internal class GetAtributosQueryHandler : IRequestHandler<GetAtributosQuery, List<AtributoDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAtributosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<AtributoDto>> Handle(GetAtributosQuery request, CancellationToken cancellationToken)
        {
                var connection = this._sqlConnectionFactory.GetOpenConnection();

                string wheresql = request.atributoID != 0 ? "Where idAtributo = " + request.atributoID : "";
                string sql = "SELECT idAtributo,vchAtributo FROM [clips_atributos] " + wheresql;

                var atributos = await connection.QueryAsync<AtributoDto>(sql);

                return atributos.AsList();
        }

    }
}