using AutoMapper;
using System.Linq.Expressions;
using System.Net;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Models.Dto.Create;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Service
{
    public class LectureSchedulesService : ILectureSchedulesService
    {
        private readonly ILectureScheduleRepository _db;
        private readonly IBasicDataService _basicDataService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public LectureSchedulesService(ILectureScheduleRepository db,
            IMapper mapper, IBasicDataService basicDataService)
        {
            _db = db;
            _response = new();
            _mapper = mapper;
            _basicDataService = basicDataService;
        }

        public async Task<APIResponse> GetAll(SearchFilterDto filterDto)
        {
            try
            {
                var response = await _basicDataService.CheckBasicData(filterDto);
                if (!response.IsSuccess)
                {
                    return response;
                }

                var ExpressionFilter = GetFilter(filterDto);
                var lecScheduleList = await _db.GetAllAsync(filter: ExpressionFilter);
                if (lecScheduleList == null)
                {
                    return _response.NotFound();
                }

                _response.Result = _mapper.Map<IEnumerable<LectureScheduleDto>>(lecScheduleList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }
        private static Expression<Func<LectureSchedule, bool>> GetFilter(SearchFilterDto filterDto)
        {
            Expression<Func<LectureSchedule, bool>>? ExpressionFilter = s => 
                                    s.CourseEnrollment.DeptCode == filterDto.DeptCode.ToUpper() && 
                                    s.CourseEnrollment.AcYear == filterDto.AcYear && 
                                    s.CourseEnrollment.ClassNo == filterDto.ClassNo;

            if (filterDto.SemNo > 0)
            {
                ExpressionFilter = s => s.CourseEnrollment.DeptCode == filterDto.DeptCode.ToUpper() && 
                                        s.CourseEnrollment.AcYear == filterDto.AcYear && 
                                        s.CourseEnrollment.ClassNo == filterDto.ClassNo && 
                                        s.CourseEnrollment.SemNo == filterDto.SemNo;
            }

            return ExpressionFilter;
        }

        public async Task<APIResponse> Create(CreateLectureScheduleDto dto)
        {
            try
            {
                if (dto.DayOfWeek > 7 || dto.DayOfWeek < 1)
                {
                    return _response.BadRequest("Please enter correct day");
                }
                LectureSchedule lectureSchedule = new();
                lectureSchedule = _mapper.Map<LectureSchedule>(dto);
                await _db.CreateAsync(lectureSchedule);

                if (lectureSchedule.Id == 0)
                {
                    return _response.BadRequest("Error: Record hasn't been created");
                }

                _response.Result = _mapper.Map<LectureScheduleDto>(lectureSchedule);
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }
    }
}
