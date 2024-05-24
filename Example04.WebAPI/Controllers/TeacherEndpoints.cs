using Example04.WebAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace Example04.WebAPI.Controllers;

public static class TeacherEndpoints
{
    public static void MapTeacherEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Teacher").WithTags(nameof(Teacher));

        group.MapGet("/", () =>
        {
            return new [] { new Teacher() };
        })
        .WithName("GetAllTeachers")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Teacher { ID = id };
        })
        .WithName("GetTeacherById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Teacher input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateTeacher")
        .WithOpenApi();

        group.MapPost("/", (Teacher model) =>
        {
            //return TypedResults.Created($"/api/Teachers/{model.ID}", model);
        })
        .WithName("CreateTeacher")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Teacher { ID = id });
        })
        .WithName("DeleteTeacher")
        .WithOpenApi();
    }
}
