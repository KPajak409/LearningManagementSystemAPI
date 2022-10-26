using System.Runtime.Serialization;

namespace LearningManagementSystemAPI.Middleware
{
    [Serializable]
    internal class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {

        }

    }
}