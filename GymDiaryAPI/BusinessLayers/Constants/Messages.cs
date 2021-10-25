namespace GymDiaryAPI.BusinessLayers.Constants
{
    public static class Messages
    {
        const string DefaultError = "Ooops, something went wrong. Please, try again later";

        public static string EntitySuccesfullyDeleted(string name) => $"{ name } successfully deleted";

        public static string EntitySuccessfullyUpdated(string name) => $"{ name } successfully modified";

        public static string EntitySuccessfullyCreated(string name) => $"{ name } sucessfully created";

        public static string EntityNotFound(string name) => $"{ name } was not found";
    }
}
