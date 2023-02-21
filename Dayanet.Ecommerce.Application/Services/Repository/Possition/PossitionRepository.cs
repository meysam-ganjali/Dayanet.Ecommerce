using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Possition;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Repository.Possition;

public class PossitionRepository : IPossitionRepository {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public PossitionRepository(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto> CreateAsync(CreatePossitionDto createPossitionDto) {
        var possition = _mapper.Map<Domain.Entities.Common.Possition>(createPossitionDto);
        await _db.Possitions.AddAsync(possition);
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "مکان جدید ثبت شد"
        };
    }

    public async Task<ResultDto> UpdateAsync(UpdatePossitionDto createPossitionDto) {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PossitionDto>> GetAllAsync() {
        var possitions = await _db.Possitions.ToListAsync();
        return _mapper.Map<IEnumerable<PossitionDto>>(possitions);
    }

    public async Task<ResultDto<PossitionDto>> GetByIdAsync(int id) {
        throw new NotImplementedException();
    }

    public async Task<ResultDto> RemoveAsync(int id) {
        throw new NotImplementedException();
    }
}