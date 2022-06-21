namespace DDDConcept.SharedKernel.X
{
    public static class Ex
    {
        public static T GetInstance<T>(this HttpContext context)
        {
            return context.RequestServices.GetRequiredService<T>();
        }
    }
}
