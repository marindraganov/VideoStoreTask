namespace VideoStore
{
    using System.Collections.Generic;

    public interface IStatementCustomer
    {
        string Name { get; }

        IReadOnlyCollection<IRental> Rentals { get; }
    }
}
