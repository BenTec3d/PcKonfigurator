using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PcKonfigurator.API.Entities;
using PcKonfigurator.API.Repositories;
using PcKonfigurator.API.Services;
using PcKonfigurator.Shared.DTOs;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.API.Controllers
{
    [Route("api/v:{version:apiVersion}/components")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ComponentsController : ControllerBase
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IPcBuildService _pcBuildService;
        private readonly IMapper _mapper;

        public ComponentsController(IComponentRepository componentRepository, IPcBuildService pcBuildService, IMapper mapper)
        {
            _componentRepository = componentRepository ?? throw new ArgumentNullException(nameof(componentRepository));
            _pcBuildService = pcBuildService ?? throw new ArgumentNullException(nameof(pcBuildService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("case/compatible")]
        public async Task<ActionResult<IEnumerable<Case>>> GetCompatibleCases([FromQuery] PcBuildBaseDto pcBuildBaseDto)
        {
            var pcBuildBase = await _pcBuildService.CreatePcBuildBaseFromDto(pcBuildBaseDto);

            var result = await _componentRepository.GetCompatibleCasesAsync(pcBuildBase);

            var mappedResult = _mapper.Map<IEnumerable<Case>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("cpu/compatible")]
        public async Task<ActionResult<IEnumerable<Cpu>>> GetCompatibleCpus([FromQuery] PcBuildBaseDto pcBuildBaseDto)
        {
            var pcBuildBase = await _pcBuildService.CreatePcBuildBaseFromDto(pcBuildBaseDto);

            var result = await _componentRepository.GetCompatibleCpusAsync(pcBuildBase);

            var mappedResult = _mapper.Map<IEnumerable<Cpu>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("cpucooler/compatible")]
        public async Task<ActionResult<IEnumerable<CpuCooler>>> GetCompatibleCpuCoolers([FromQuery] PcBuildBaseDto pcBuildBaseDto)
        {
            var pcBuildBase = await _pcBuildService.CreatePcBuildBaseFromDto(pcBuildBaseDto);

            var result = await _componentRepository.GetCompatibleCpuCoolersAsync(pcBuildBase);

            var mappedResult = _mapper.Map<IEnumerable<CpuCooler>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("gpu/compatible")]
        public async Task<ActionResult<IEnumerable<Gpu>>> GetCompatibleGpus([FromQuery] PcBuildBaseDto pcBuildBaseDto)
        {
            var pcBuildBase = await _pcBuildService.CreatePcBuildBaseFromDto(pcBuildBaseDto);

            var result = await _componentRepository.GetCompatibleGpusAsync(pcBuildBase);

            var mappedResult = _mapper.Map<IEnumerable<Gpu>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("motherboard/compatible")]
        public async Task<ActionResult<IEnumerable<Motherboard>>> GetCompatibleMotherboards([FromQuery] PcBuildBaseDto pcBuildBaseDto)
        {
            var pcBuildBase = await _pcBuildService.CreatePcBuildBaseFromDto(pcBuildBaseDto);

            var result = await _componentRepository.GetCompatibleMotherboardsAsync(pcBuildBase);

            var mappedResult = _mapper.Map<IEnumerable<Motherboard>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("psu/compatible")]
        public async Task<ActionResult<IEnumerable<Psu>>> GetCompatiblePsus([FromQuery] PcBuildBaseDto pcBuildBaseDto)
        {
            var pcBuildBase = await _pcBuildService.CreatePcBuildBaseFromDto(pcBuildBaseDto);

            var result = await _componentRepository.GetCompatiblePsusAsync(pcBuildBase);

            var mappedResult = _mapper.Map<IEnumerable<Psu>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("ram/compatible")]
        public async Task<ActionResult<IEnumerable<Ram>>> GetCompatibleRams([FromQuery] PcBuildBaseDto pcBuildBaseDto)
        {
            var pcBuildBase = await _pcBuildService.CreatePcBuildBaseFromDto(pcBuildBaseDto);

            var result = await _componentRepository.GetCompatibleRamsAsync(pcBuildBase);

            var mappedResult = _mapper.Map<IEnumerable<Ram>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("storage/compatible")]
        public async Task<ActionResult<IEnumerable<Storage>>> GetCompatibleStorages([FromQuery] PcBuildBaseDto pcBuildBaseDto)
        {
            var pcBuildBase = await _pcBuildService.CreatePcBuildBaseFromDto(pcBuildBaseDto);

            var result = await _componentRepository.GetCompatibleStoragesAsync(pcBuildBase);

            var mappedResult = _mapper.Map<IEnumerable<Storage>>(result);

            return Ok(mappedResult);
        }
    }
}
