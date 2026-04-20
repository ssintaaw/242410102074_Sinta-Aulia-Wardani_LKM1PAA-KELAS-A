CREATE TYPE size_enum AS ENUM ('S','M','L','XL');
CREATE TYPE status_enum AS ENUM ('dipinjam','dikembalikan');

CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100),
    phone VARCHAR(20),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE costumes (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100),
    size size_enum,
    price NUMERIC(10,2),
    stock INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE rentals (
    id SERIAL PRIMARY KEY,
    customer_id INT,
    costume_id INT,
    rent_date DATE,
    return_date DATE,
    status status_enum,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    deleted_at TIMESTAMP,

    FOREIGN KEY (customer_id) REFERENCES customers(id),
    FOREIGN KEY (costume_id) REFERENCES costumes(id)
);

CREATE INDEX idx_customer ON rentals(customer_id);
CREATE INDEX idx_costume ON rentals(costume_id);

INSERT INTO customers (name, phone) VALUES
('Bianca', '081234567890'),
('Andi', '081111111111'),
('Siti', '082222222222'),
('Budi', '083333333333'),
('Rina', '084444444444');

INSERT INTO costumes (name, size, price, stock) VALUES
('Kostum Adat', 'M', 50000, 5),
('Kostum Polisi', 'L', 70000, 3),
('Kostum Dokter', 'S', 60000, 4),
('Kostum Pahlawan', 'XL', 80000, 2),
('Kostum Pesta', 'M', 75000, 6);

INSERT INTO rentals (customer_id, costume_id, rent_date, return_date, status) VALUES
(1,1,'2026-04-20','2026-04-22','dipinjam'),
(2,2,'2026-04-20','2026-04-21','dikembalikan'),
(3,3,'2026-04-21','2026-04-23','dipinjam'),
(4,4,'2026-04-21','2026-04-22','dikembalikan'),
(5,5,'2026-04-22','2026-04-24','dipinjam');