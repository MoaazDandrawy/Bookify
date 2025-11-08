namespace Bookify.Application.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }
        public IEnumerable<ValidationError> Errors { get; }//hoa bigam3 el errors kolha m3 ba3d w yrmiha mara wa7da badl ma yrmy error error
    }
}
