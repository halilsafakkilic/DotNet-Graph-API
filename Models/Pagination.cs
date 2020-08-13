using GraphQL.Types;

namespace netCoreGraphQL.Models
{
    public class Pagination
    {
        private const int MAX_SIZE = 10;
        private const int DEFAULT_SIZE = 5;

        public static Pagination CreateInstanceFromQuery(ResolveFieldContext<object> ctx)
        {
            var page = ctx.GetArgument<int>("page", 1);
            var size = ctx.GetArgument<int>("size", DEFAULT_SIZE);

            return new Pagination { Page = page, Size = size };
        }

        public int Page { get; set; } = 1;

        private int _Size { get; set; } = DEFAULT_SIZE;

        public int Size
        {
            get
            {
                return _Size;
            }

            set
            {
                if (value > MAX_SIZE)
                {
                    value = DEFAULT_SIZE;
                }

                _Size = value;
            }
        }

        public int Skip
        {
            get
            {
                return (this.Page - 1) * this.Size;
            }

            private set { }
        }
    }

    public static class PaginationType
    {
        public static QueryArguments GetQueryArgumentsForPagination(QueryArguments queryArguments = null)
        {
            if (queryArguments == null)
            {
                queryArguments = new QueryArguments();
            }

            queryArguments.Add(
                new QueryArgument<IntGraphType>
                {
                    Name = "Page",
                    Description = "Requested page number."
                }
            );

            queryArguments.Add(
                new QueryArgument<IntGraphType>
                {
                    Name = "Size",
                    Description = "Item limit per page."
                }
            );

            return queryArguments;
        }
    }
}