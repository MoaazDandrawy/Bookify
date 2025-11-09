using Dapper;
using System.Data;

namespace Bookify.Infrastructure.Data
{
    internal sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        //el Dapper msh bi3rf yt3aml m3 el DateOnly Type f m7tag handler 3lshan y2dr yfham
        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = value;
        }

        public override DateOnly Parse(object value)
        {
            return DateOnly.FromDateTime((DateTime)value);
        }
    }
}
