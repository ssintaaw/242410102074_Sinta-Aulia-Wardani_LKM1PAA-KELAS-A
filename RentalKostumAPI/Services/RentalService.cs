using Npgsql;
using RentalKostumAPI.Model;

namespace RentalKostumAPI.Services
{
    public class RentalService
    {
        private readonly IConfiguration _config;
        private string connectionString;

        public RentalService(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString("DefaultConnection");
        }

        // GET ALL
        public List<Rental> GetAll()
        {
            var list = new List<Rental>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM rentals WHERE deleted_at IS NULL";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Rental
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Customer_Id = Convert.ToInt32(reader["customer_id"]),
                            Costume_Id = Convert.ToInt32(reader["costume_id"]),
                            Rent_Date = Convert.ToDateTime(reader["rent_date"]),
                            Return_Date = Convert.ToDateTime(reader["return_date"]),
                            Status = reader["status"]?.ToString() ?? ""
                        });
                    }
                }
            }

            return list;
        }

        // GET BY ID
        public Rental GetById(int id)
        {
            Rental rental = null;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM rentals WHERE id = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rental = new Rental
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Customer_Id = Convert.ToInt32(reader["customer_id"]),
                                Costume_Id = Convert.ToInt32(reader["costume_id"]),
                                Rent_Date = Convert.ToDateTime(reader["rent_date"]),
                                Return_Date = Convert.ToDateTime(reader["return_date"]),
                                Status = reader["status"]?.ToString() ?? ""
                            };
                        }
                    }
                }
            }

            return rental;
        }

        // CREATE
        public void Create(Rental rental)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO rentals 
                (customer_id, costume_id, rent_date, return_date, status)
                VALUES (@customer_id, @costume_id, @rent_date, @return_date, @status::status_enum)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", rental.Customer_Id);
                    cmd.Parameters.AddWithValue("@costume_id", rental.Costume_Id);
                    cmd.Parameters.AddWithValue("@rent_date", rental.Rent_Date);
                    cmd.Parameters.AddWithValue("@return_date", rental.Return_Date);
                    cmd.Parameters.AddWithValue("@status", rental.Status);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // UPDATE
        public void Update(int id, Rental rental)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"UPDATE rentals SET 
                customer_id=@customer_id,
                costume_id=@costume_id,
                rent_date=@rent_date,
                return_date=@return_date,
                status=@status::status_enum
                WHERE id=@id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@customer_id", rental.Customer_Id);
                    cmd.Parameters.AddWithValue("@costume_id", rental.Costume_Id);
                    cmd.Parameters.AddWithValue("@rent_date", rental.Rent_Date);
                    cmd.Parameters.AddWithValue("@return_date", rental.Return_Date);
                    cmd.Parameters.AddWithValue("@status", rental.Status);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE (SOFT DELETE)
        public void Delete(int id)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE rentals SET deleted_at = CURRENT_TIMESTAMP WHERE id=@id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}