using System;
using AutoMapper;
using FluentValidation;
using TestTemplate15.Application.Foos.Commands;

namespace TestTemplate15.Api.Models;

public record UpdateFooRequest(Guid Id, string Text);

public class UpdateFooRequestValidator : AbstractValidator<UpdateFooRequest>
{
    public UpdateFooRequestValidator()
    {
        RuleFor(x => x.Text).MinimumLength(5);
    }
}

public class UpdateFooRequestProfile : Profile
{
    public UpdateFooRequestProfile()
    {
        CreateMap<UpdateFooRequest, UpdateFooCommand>();
    }
}
