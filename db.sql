-- ====================================================
-- DATABASE: school_management
-- ====================================================

SET NAMES 'utf8mb4';
DROP DATABASE IF EXISTS school_management;
CREATE DATABASE school_management
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE school_management;

-- =====================================
-- 1. USERS (Đã thêm avatar)
-- =====================================
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL DEFAULT '123456',
    fullname VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    phone VARCHAR(15),
    avatar VARCHAR(255) DEFAULT 'avatar_macdinh.png', -- Mặc định có ảnh
    role_id VARCHAR(50),  -- admin, gvcn, gvbm, student, parent
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO users (username, fullname, role_id, email, phone, avatar) VALUES
-- 1 Admin
('admin', 'Ban Giám Hiệu', 'admin', 'admin@school.edu.vn', '0909000000', 'admin.png'),

-- 3 Giáo viên
('gv01', 'Trần Thị Mai (CN 6A1)', 'gvcn', 'mai.tran@school.edu.vn', '0909000001', 'teacher_female.png'),
('gv02', 'Nguyễn Văn Hùng (CN 6A2)', 'gvcn', 'hung.nguyen@school.edu.vn', '0909000002', 'teacher_male.png'),
('gv03', 'Lê Thị Lan (Anh Văn)', 'gvbm', 'lan.le@school.edu.vn', '0909000003', 'teacher_female.png'),

-- 12 Học sinh (Username dạng hs + số ngẫu nhiên để test)
('hs100001', 'Nguyễn Minh Khang', 'student', 'hs01@school.edu.vn', '', 'student_boy.png'),
('hs100002', 'Trần Bảo Ngọc', 'student', 'hs02@school.edu.vn', '', 'student_girl.png'),
('hs100003', 'Lê Thị Cẩm Ly', 'student', 'hs03@school.edu.vn', '', 'student_girl.png'),
('hs100004', 'Phạm Văn Đức', 'student', 'hs04@school.edu.vn', '', 'student_boy.png'),
('hs100005', 'Hoàng Thái Tú', 'student', 'hs05@school.edu.vn', '', 'student_boy.png'),
('hs100006', 'Vũ Thị Mai', 'student', 'hs06@school.edu.vn', '', 'student_girl.png'),
('hs100007', 'Đặng Tuấn Anh', 'student', 'hs07@school.edu.vn', '', 'student_boy.png'),
('hs100008', 'Bùi Thị Hoa', 'student', 'hs08@school.edu.vn', '', 'student_girl.png'),
('hs100009', 'Ngô Văn Nam', 'student', 'hs09@school.edu.vn', '', 'student_boy.png'),
('hs100010', 'Đỗ Thị Hạnh', 'student', 'hs10@school.edu.vn', '', 'student_girl.png'),
('hs100011', 'Lý Văn Phúc', 'student', 'hs11@school.edu.vn', '', 'student_boy.png'),
('hs100012', 'Hồ Thị Thu', 'student', 'hs12@school.edu.vn', '', 'student_girl.png'),

-- 12 Phụ huynh
('ph100001', 'Lê Văn Bố (PH Khang)', 'parent', 'ph01@gmail.com', '0911000001', NULL),
('ph100002', 'Trần Thị Mẹ (PH Ngọc)', 'parent', 'ph02@gmail.com', '0911000002', NULL),
('ph100003', 'Lê Văn Hùng (PH Ly)', 'parent', 'ph03@gmail.com', '0911000003', NULL),
('ph100004', 'Phạm Thị Lan (PH Đức)', 'parent', 'ph04@gmail.com', '0911000004', NULL),
('ph100005', 'Hoàng Văn Cường (PH Tú)', 'parent', 'ph05@gmail.com', '0911000005', NULL),
('ph100006', 'Vũ Văn Long (PH Mai)', 'parent', 'ph06@gmail.com', '0911000006', NULL),
('ph100007', 'Đặng Văn Sơn (PH Anh)', 'parent', 'ph07@gmail.com', '0911000007', NULL),
('ph100008', 'Bùi Văn Tám (PH Hoa)', 'parent', 'ph08@gmail.com', '0911000008', NULL),
('ph100009', 'Ngô Thị Chín (PH Nam)', 'parent', 'ph09@gmail.com', '0911000009', NULL),
('ph100010', 'Đỗ Văn Mười (PH Hạnh)', 'parent', 'ph10@gmail.com', '0911000010', NULL),
('ph100011', 'Lý Thị Một (PH Phúc)', 'parent', 'ph11@gmail.com', '0911000011', NULL),
('ph100012', 'Hồ Văn Hai (PH Thu)', 'parent', 'ph12@gmail.com', '0911000012', NULL);

-- =====================================
-- 2. PARENTS & STUDENTS
-- =====================================
CREATE TABLE parents (
    parent_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNIQUE NOT NULL,
    job VARCHAR(100),
    FOREIGN KEY(user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

INSERT INTO parents (user_id, job) VALUES
(17, 'Kỹ sư'), (18, 'Bác sĩ'), (19, 'Giáo viên'), (20, 'Kinh doanh'),
(21, 'Công chức'), (22, 'Nội trợ'), (23, 'Lái xe'), (24, 'Kế toán'),
(25, 'Công nhân'), (26, 'Nông dân'), (27, 'Luật sư'), (28, 'Kiến trúc sư');

CREATE TABLE students (
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNIQUE NOT NULL,
    dob DATE,
    gender ENUM('Male','Female'),
    address TEXT,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

INSERT INTO students (user_id, dob, gender, address) VALUES
(5, '2013-05-12', 'Male', 'Quận 1, TP.HCM'),
(6, '2013-09-21', 'Female', 'Quận 3, TP.HCM'),
(7, '2013-02-10', 'Female', 'Quận 5, TP.HCM'),
(8, '2013-03-15', 'Male', 'Quận 10, TP.HCM'),
(9, '2013-07-20', 'Male', 'Bình Thạnh, TP.HCM'),
(10, '2013-11-05', 'Female', 'Gò Vấp, TP.HCM'),
(11, '2013-01-30', 'Male', 'Quận 1, TP.HCM'),
(12, '2013-04-12', 'Female', 'Quận 2, TP.HCM'),
(13, '2013-06-18', 'Male', 'Quận 4, TP.HCM'),
(14, '2013-08-25', 'Female', 'Quận 7, TP.HCM'),
(15, '2013-10-10', 'Male', 'Quận 8, TP.HCM'),
(16, '2013-12-05', 'Female', 'Quận 9, TP.HCM');

CREATE TABLE student_parent (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    parent_id INT NOT NULL,
    relation VARCHAR(50), 
    FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (parent_id) REFERENCES parents(parent_id) ON DELETE CASCADE
);

INSERT INTO student_parent (student_id, parent_id, relation) VALUES
(1, 1, 'Cha'), (2, 2, 'Mẹ'), (3, 3, 'Cha'), (4, 4, 'Mẹ'),
(5, 5, 'Cha'), (6, 6, 'Cha'), (7, 7, 'Cha'), (8, 8, 'Cha'),
(9, 9, 'Mẹ'), (10, 10, 'Cha'), (11, 11, 'Mẹ'), (12, 12, 'Cha');

-- =====================================
-- 3. ACADEMIC & TEACHERS
-- =====================================
CREATE TABLE teachers (
    teacher_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNIQUE NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);
INSERT INTO teachers (user_id) VALUES (2), (3), (4);

CREATE TABLE academic_years (
    year_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    start_date DATE,
    end_date DATE
);
INSERT INTO academic_years (name, start_date, end_date) VALUES ('2025-2026', '2025-08-01', '2026-05-30');

CREATE TABLE semesters (
    semester_id INT AUTO_INCREMENT PRIMARY KEY,
    year_id INT NOT NULL,
    name VARCHAR(20) NOT NULL,
    start_date DATE,
    end_date DATE
);
INSERT INTO semesters (year_id, name, start_date, end_date) VALUES
(1, 'Học kỳ 1', '2025-08-01', '2025-12-31'),
(1, 'Học kỳ 2', '2026-01-01', '2026-05-30');

-- =====================================
-- 4. CLASSES
-- =====================================
CREATE TABLE grade_levels (
    grade_id INT AUTO_INCREMENT PRIMARY KEY,
    grade_name VARCHAR(20)
);
INSERT INTO grade_levels (grade_name) VALUES ('Khối 6'), ('Khối 7');

CREATE TABLE classes (
    class_id INT AUTO_INCREMENT PRIMARY KEY,
    class_name VARCHAR(50),
    grade_id INT
);
INSERT INTO classes (class_name, grade_id) VALUES ('6A1', 1), ('6A2', 1), ('7A1', 2);

CREATE TABLE homeroom_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT, teacher_id INT, year_id INT, assigned_date DATE
);
INSERT INTO homeroom_assignments (class_id, teacher_id, year_id, assigned_date) VALUES
(1, 2, 1, '2025-08-01'), 
(2, 3, 1, '2025-08-01');

CREATE TABLE student_class (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT, class_id INT, school_year_id INT,
    FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE
);
INSERT INTO student_class (student_id, class_id, school_year_id) VALUES
(1, 1, 1), (2, 1, 1), (3, 1, 1), (4, 1, 1), (5, 1, 1), (6, 1, 1),
(7, 2, 1), (8, 2, 1), (9, 2, 1), (10, 2, 1), (11, 2, 1), (12, 2, 1);

-- =====================================
-- 5. SUBJECTS & SCHEDULE
-- =====================================
CREATE TABLE subjects (
    subject_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100)
);
INSERT INTO subjects (name) VALUES 
('Toán'), ('Ngữ Văn'), ('Tiếng Anh'), ('Vật Lý'), 
('Hóa Học'), ('Sinh Học'), ('Lịch Sử'), ('Địa Lý'), ('Tin Học'), ('GDCD');

CREATE TABLE teacher_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    teacher_id INT, subject_id INT, class_id INT, semester_id INT
);
INSERT INTO teacher_assignments (teacher_id, subject_id, class_id, semester_id) VALUES
(2, 1, 1, 1), (2, 2, 1, 1), (3, 1, 2, 1), (4, 3, 1, 1), (4, 3, 2, 1);

CREATE TABLE timetable (
    id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT, subject_id INT, teacher_id INT, semester_id INT,
    day ENUM('Mon','Tue','Wed','Thu','Fri','Sat'), period INT, room VARCHAR(50)
);
INSERT INTO timetable (class_id, subject_id, teacher_id, semester_id, day, period, room) VALUES
(1, 1, 2, 1, 'Mon', 1, '101'), (1, 2, 2, 1, 'Mon', 2, '101'),
(1, 3, 4, 1, 'Tue', 1, '101'), (1, 1, 2, 1, 'Tue', 2, '101');

-- =====================================
-- 6. FINANCE & SCORES
-- =====================================
CREATE TABLE scores (
    score_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT, assign_id INT, 
    score_type ENUM('oral','quiz15','quiz45','midterm','final'),
    score_value FLOAT,
    FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE
);
INSERT INTO scores (student_id, assign_id, score_type, score_value) VALUES
(1, 1, 'oral', 8.5), (1, 1, 'quiz15', 9.0), (1, 1, 'midterm', 8.0);

CREATE TABLE tuition (
    tuition_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT, name VARCHAR(255), amount DECIMAL(10,2),
    semester_id INT, due_date DATE, status ENUM('unpaid','paid'),
    FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE
);
INSERT INTO tuition (student_id, name, amount, semester_id, due_date, status) VALUES
(1, 'Học phí HK1', 5000000, 1, '2025-09-30', 'paid'),
(2, 'Học phí HK1', 5000000, 1, '2025-09-30', 'unpaid');

-- =====================================
-- 7. EXTRAS (Comments, Events, Notifications)
-- =====================================
CREATE TABLE notifications (
    id INT AUTO_INCREMENT PRIMARY KEY,
    sender_id INT, target_role VARCHAR(50), title VARCHAR(200), message TEXT, created_at DATETIME
);
INSERT INTO notifications (sender_id, target_role, title, message, created_at) VALUES
(1, 'all', 'Chào mừng năm học mới 2025-2026', 'Chúc mừng năm học mới!', '2025-08-01 07:00:00');

CREATE TABLE school_info (
    school_id INT AUTO_INCREMENT PRIMARY KEY,
    school_name VARCHAR(200), address TEXT, phone VARCHAR(20)
);
INSERT INTO school_info VALUES (1, 'THCS Minh Khai', 'Quận 1, TP.HCM', '02822223333');

-- Bảng Comments (Nếu bạn cần dùng sau này)
CREATE TABLE comments (
    comment_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    content TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

-- Bảng Events (Sự kiện)
CREATE TABLE events (
    event_id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255),
    description TEXT,
    event_date DATETIME
);
INSERT INTO events (title, description, event_date) VALUES 
('Khai giảng', 'Lễ khai giảng năm học mới', '2025-09-05 07:00:00');