using AutoMapper;
using backend.Dtos;
using backend.Interface;
using backend.Queries.PregledQueries;
using MediatR;

namespace backend.Handlers.PregledHandlers
{
    public class GetPregledByIdHandler : IRequestHandler<GetPregledByIdQuery, GetPregledDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPregledByIdHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<GetPregledDto> Handle(GetPregledByIdQuery request, CancellationToken cancellationToken)
        {
            var pregled = await uow.PregledRepository.GetPregledAsync(request.Id);

            return  mapper.Map<GetPregledDto>(pregled);
        }
    }
}
