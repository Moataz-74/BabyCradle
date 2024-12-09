namespace BabyCradle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineRepository medicineRepository;

        public MedicinesController(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddMedicine(AddMedicineDTO medicineDTO)
        {
            if (ModelState.IsValid)
            {
                await medicineRepository.AddMedicine(medicineDTO);
                return Ok("Medicine Added");
            }
            return BadRequest("Invalid input");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetAllMedicines()
        {
            var medicines = await medicineRepository.GetAllMedicines();
            return medicines.ToList();
        }

        [Authorize]
        [HttpPut("EditMedicine/{id}")]
        public async Task<IActionResult> EditMedicine(int id, EditMedicineDTO editMedicineDTO)
        {
            if (ModelState.IsValid)
            {
                await medicineRepository.EditMedicine(id, editMedicineDTO);
                return Ok("Modified successfully");
            }
            return BadRequest("Invalid input");
        }

        [Authorize]
        [HttpDelete("DeleteMedicine/{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            await medicineRepository.DeleteMedicine(id);
            return Ok("Medicine deleted");
        }
    }
}
