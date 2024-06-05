using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uyg03.Dtos;
using uyg03.Models;

namespace uyg03.Controllers
{
    [Route("api/Educations")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public EducationsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<EducationDto> GetList()
        {
            var Educations = _context.Educations.ToList();
            var EducationDtos = _mapper.Map<List<EducationDto>>(Educations);
            return EducationDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public EducationDto Get(int id)
        {
            var Education = _context.Educations.Where(s => s.Id == id).SingleOrDefault();
            var EducationDto = _mapper.Map<EducationDto>(Education);
            return EducationDto;
        }

        [HttpPost]
        public ResultDto Post(EducationDto dto)
        {
            if (_context.Educations.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Cevap Kayıtlıdır!";
                return result;
            }
            var Education = _mapper.Map<Education>(dto);
            Education.Updated = DateTime.Now;
            Education.Created = DateTime.Now;
            _context.Educations.Add(Education);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Cevap Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(EducationDto dto)
        {
            var Education = _context.Educations.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (Education == null)
            {
                result.Status = false;
                result.Message = "Cevap Bulunamadı!";
                return result;
            }
            Education.Name = dto.Name;
            Education.Updated = DateTime.Now;
            Education.CategoryId = dto.CategoryId;
            _context.Educations.Update(Education);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Cevap Düzenlendi";
            return result;
        }

        
        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var Education = _context.Educations.Where(s => s.Id == id).SingleOrDefault();
            if (Education == null)
            {
                result.Status = false;
                result.Message = "Cevap Bulunamadı!";
                return result;
            }
            _context.Educations.Remove(Education);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Cevap Silindi";
            return result;
        }
    }
}
