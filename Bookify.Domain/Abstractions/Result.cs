using System.Diagnostics.CodeAnalysis;

namespace Bookify.Domain.Abstractions
{
    public class Result
    {
        protected internal Result(bool isSuccess, Error error)
        {
            // el conditions elgaya di 3lshan ymn3 en fih 7ala 8ariba yt3mlha create y3ny lazm tlama en IsSuccess b true tkon el Error b None w el3aks sa7i7
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }
            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess; //property
        public Error Error { get; }

        //some helper static methods
        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
        public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

        public static Result<TValue> Create<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
    }
    //f el result 3amlna noo3 generic 3lshan lw el 3amlia bta3ty rag3t value zay getUserById el user hena lw rg3 hoa da el value lakn 7aga zai saveChanges() mfhash value f hanst5dm el noo3 el 3ady
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }
        [NotNull]
        //hena enta t2dr twsl l el value only if en el result successed 8er keda mt2drsh twsl l el value
        public TValue value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result can not be accessed.");

        //di 3lshan y5ali for example Result<Booking> hia hia Booking
        public static implicit operator Result<TValue>(TValue? value) => Create(value);
    }
}
