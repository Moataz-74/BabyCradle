namespace BabyCradle.Repository
{
    public interface IMedicineRepository
    {
        Task<bool> MedicineExistsAsync(int id);

        Task AddMedicine(AddMedicineDTO medicineDTO);

        Task<IEnumerable<Medicine>> GetAllMedicines();

        Task EditMedicine(int id, EditMedicineDTO medicineDTO);

        Task DeleteMedicine(int id);
    }
}
