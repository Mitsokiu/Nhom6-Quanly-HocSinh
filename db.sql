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
    user_id INT,
    dob DATE,
    gender ENUM('Male','Female'),
    address TEXT,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

<<<<<<< HEAD
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

=======
CREATE TABLE grade_levels (
    grade_id INT AUTO_INCREMENT PRIMARY KEY,
    grade_name VARCHAR(20)
);

CREATE TABLE classes (
    class_id INT AUTO_INCREMENT PRIMARY KEY,
    class_name VARCHAR(50),
    grade_id INT,
    FOREIGN KEY (grade_id) REFERENCES grade_levels(grade_id)
);

>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
CREATE TABLE academic_years (
    year_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20),
    start_date DATE,
    end_date DATE
);
<<<<<<< HEAD
INSERT INTO academic_years (name, start_date, end_date) VALUES ('2025-2026', '2025-08-01', '2026-05-30');
=======
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c

CREATE TABLE semesters (
    semester_id INT AUTO_INCREMENT PRIMARY KEY,
    year_id INT,
    name VARCHAR(20),
    start_date DATE,
    end_date DATE
);
<<<<<<< HEAD
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

DROP TABLE IF EXISTS `attendance`;
CREATE TABLE `attendance` (
  `attendance_id` int NOT NULL AUTO_INCREMENT,
  `student_id` int NOT NULL,
  `class_id` int NOT NULL,
  `date` date NOT NULL,
  `status` enum('absent_permit','absent_no_permit','late') COLLATE utf8mb4_unicode_ci NOT NULL,
  `note` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`attendance_id`),
  UNIQUE KEY `unique_attendance` (`student_id`,`date`),
  KEY `class_id` (`class_id`),
  CONSTRAINT `attendance_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE,
  CONSTRAINT `attendance_ibfk_2` FOREIGN KEY (`class_id`) REFERENCES `classes` (`class_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


-- =====================================
-- 5. SUBJECTS & SCHEDULE
-- =====================================
=======

>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
CREATE TABLE subjects (
    subject_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100)
);
<<<<<<< HEAD
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


DROP TABLE IF EXISTS `student_evaluations`;
CREATE TABLE `student_evaluations` (
  `evaluation_id` int NOT NULL AUTO_INCREMENT,
  `student_id` int NOT NULL,
  `class_id` int NOT NULL,
  `semester_id` int NOT NULL,
  `conduct` enum('Tốt','Khá','Trung Bình','Yếu') COLLATE utf8mb4_unicode_ci DEFAULT 'Tốt',
  `teacher_comment` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`evaluation_id`),
  UNIQUE KEY `unique_eval` (`student_id`,`class_id`,`semester_id`),
  KEY `class_id` (`class_id`),
  KEY `semester_id` (`semester_id`),
  CONSTRAINT `student_evaluations_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE,
  CONSTRAINT `student_evaluations_ibfk_2` FOREIGN KEY (`class_id`) REFERENCES `classes` (`class_id`),
  CONSTRAINT `student_evaluations_ibfk_3` FOREIGN KEY (`semester_id`) REFERENCES `semesters` (`semester_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `student_evaluations`
--

LOCK TABLES `student_evaluations` WRITE;
/*!40000 ALTER TABLE `student_evaluations` DISABLE KEYS */;
INSERT INTO `student_evaluations` VALUES (1,4,1,2,'Tốt',''),(2,1,1,2,'Tốt',''),(3,3,1,2,'Khá',''),(4,6,1,2,'Trung Bình',''),(5,2,1,2,'Yếu',''),(8,4,1,1,'Tốt','');
/*!40000 ALTER TABLE `student_evaluations` ENABLE KEYS */;
UNLOCK TABLES;

--

-- Bảng Events (Sự kiện)
CREATE TABLE events (
    event_id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255),
    description TEXT,
    event_date DATETIME
);
INSERT INTO events (title, description, event_date) VALUES 
('Khai giảng', 'Lễ khai giảng năm học mới', '2025-09-05 07:00:00');
=======

CREATE TABLE teacher_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    teacher_id INT,
    subject_id INT,
    class_id INT,
    semester_id INT,
    periods INT,
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (subject_id) REFERENCES subjects(subject_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE timetable (
    id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT,
    subject_id INT,
    teacher_id INT,
    semester_id INT,
    day ENUM('Mon','Tue','Wed','Thu','Fri','Sat'),
    period INT,
    room VARCHAR(50),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (subject_id) REFERENCES subjects(subject_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE tuition (
    tuition_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    description VARCHAR(255),
    name VARCHAR(255),
    amount DECIMAL(10,2),
    semester_id INT,
    due_date DATE,
    status ENUM('unpaid','paid'),
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE student_evaluations (
    evaluation_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    class_id INT,
    semester_id INT,
    conduct ENUM('Tốt','Khá','Trung Bình','Yếu'),
    teacher_comment TEXT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id),
    UNIQUE KEY unique_eval (student_id, class_id, semester_id)
);

CREATE TABLE student_class (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    class_id INT,
    school_year_id INT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (school_year_id) REFERENCES academic_years(year_id)
);

CREATE TABLE scores (
    score_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    assign_id INT,
    score_type ENUM('oral','quiz15','quiz45','midterm','final','ave'),
    score_value FLOAT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (assign_id) REFERENCES teacher_assignments(assign_id)
);

CREATE TABLE school_info (
    school_id INT AUTO_INCREMENT PRIMARY KEY,
    school_name VARCHAR(200),
    address TEXT,
    phone VARCHAR(20)
);

CREATE TABLE notifications (
    id INT AUTO_INCREMENT PRIMARY KEY,
    sender_id INT,
    target_role ENUM('teacher','student','parent','all'),
    title VARCHAR(200),
    message TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (sender_id) REFERENCES users(user_id)
);

CREATE TABLE homeroom_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT,
    teacher_id INT,
    year_id INT,
    assigned_date DATE,
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (year_id) REFERENCES academic_years(year_id)
);

CREATE TABLE grade_rank (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rank_name VARCHAR(50),
    min_score FLOAT,
    max_score FLOAT
);

CREATE TABLE comments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    teacher_id INT,
    semester_id INT,
    comment_text TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

-- ======================================
-- INSERT DATA
-- ======================================
-- USERS: 5 admin, 5 student, 5 gvcn, 5 gvbm
INSERT INTO users (username,password,fullname,email,phone,role_id) VALUES
('admin1','123','Admin One','admin1@mail.com','0900000001','admin'),
('admin2','123','Admin Two','admin2@mail.com','0900000002','admin'),
('admin3','123','Admin Three','admin3@mail.com','0900000003','admin'),
('admin4','123','Admin Four','admin4@mail.com','0900000004','admin'),
('admin5','123','Admin Five','admin5@mail.com','0900000005','admin'),

('student1','123','Student One','st1@mail.com','0911111111','student'),
('student2','123','Student Two','st2@mail.com','0911111112','student'),
('student3','123','Student Three','st3@mail.com','0911111113','student'),
('student4','123','Student Four','st4@mail.com','0911111114','student'),
('student5','123','Student Five','st5@mail.com','0911111115','student'),

('gvcn1','123','GVCN One','gvcn1@mail.com','0922222221','gvcn'),
('gvcn2','123','GVCN Two','gvcn2@mail.com','0922222222','gvcn'),
('gvcn3','123','GVCN Three','gvcn3@mail.com','0922222223','gvcn'),
('gvcn4','123','GVCN Four','gvcn4@mail.com','0922222224','gvcn'),
('gvcn5','123','GVCN Five','gvcn5@mail.com','0922222225','gvcn'),

('gvbm1','123','GVBM One','gvbm1@mail.com','0933333331','gvbm'),
('gvbm2','123','GVBM Two','gvbm2@mail.com','0933333332','gvbm'),
('gvbm3','123','GVBM Three','gvbm3@mail.com','0933333333','gvbm'),
('gvbm4','123','GVBM Four','gvbm4@mail.com','0933333334','gvbm'),
('gvbm5','123','GVBM Five','gvbm5@mail.com','0933333335','gvbm');

-- STUDENTS = 5
INSERT INTO students (user_id,dob,gender,address)
SELECT user_id,'2010-01-01','Male','HCM City'
FROM users WHERE role_id='student';

-- GRADE LEVELS
INSERT INTO grade_levels (grade_name) VALUES
('Grade 6'),('Grade 7'),('Grade 8');

-- CLASSES
INSERT INTO classes (class_name,grade_id) VALUES
('6A1',1),('6A2',1),
('7A1',2),('7A2',2),
('8A1',3);

-- ACADEMIC YEARS
INSERT INTO academic_years (name,start_date,end_date) VALUES
('2024-2025','2024-09-01','2025-05-31');

-- SEMESTERS
INSERT INTO semesters (year_id,name,start_date,end_date) VALUES
(1,'HK1','2025-09-01','2025-12-31'),
(1,'HK2','2026-01-01','2026-05-31');

-- SUBJECTS
INSERT INTO subjects(name) VALUES
('Math'),('Physics'),('Chemistry'),('English'),('History');

-- TEACHER ASSIGNMENTS
INSERT INTO teacher_assignments(teacher_id,subject_id,class_id,semester_id,periods) VALUES
(11,1,1,1,4),
(12,2,1,1,3),
(13,3,2,1,2),
(14,4,2,1,3),
(15,5,3,1,2);

-- TIMETABLE
INSERT INTO timetable(class_id,subject_id,teacher_id,semester_id,day,period,room) VALUES
(1,1,11,1,'Mon',1,'A1'),
(1,2,12,1,'Tue',2,'A1'),
(2,3,13,1,'Wed',3,'A2');

-- TUITION
INSERT INTO tuition(student_id,description,name,amount,semester_id,due_date,status) VALUES
(1,'Học phí HK1','Tuition HK1',2000000,1,'2024-10-01','unpaid'),
(2,'Học phí HK1','Tuition HK1',2000000,1,'2024-10-01','paid');

-- STUDENT EVALUATIONS
INSERT INTO student_evaluations(student_id,class_id,semester_id,conduct,teacher_comment) VALUES
(1,1,1,'Tốt','Chăm ngoan'),
(2,1,1,'Khá','Tiến bộ');

-- STUDENT CLASS
INSERT INTO student_class(student_id,class_id,school_year_id) VALUES
(1,1,1),(2,1,1),(3,2,1),(4,2,1),(5,3,1);

-- SCORES
INSERT INTO scores(student_id,assign_id,score_type,score_value) VALUES
(1,1,'oral',9),
(1,1,'quiz15',8),
(1,1,'final',9.5);

-- SCHOOL INFO
INSERT INTO school_info(school_name,address,phone) VALUES
('Trường THCS ABC','HCM City','0900009999');

-- NOTIFICATIONS
INSERT INTO notifications(sender_id,target_role,title,message) VALUES
(1,'all','Thông báo khai giảng','Ngày khai giảng 5/9');

-- HOMEROOM ASSIGNMENTS
INSERT INTO homeroom_assignments(class_id,teacher_id,year_id,assigned_date) VALUES
(1,11,1,'2024-08-20');

-- GRADE RANK
INSERT INTO grade_rank(rank_name,min_score,max_score) VALUES
('Giỏi',8.0,10.0),
('Khá',6.5,7.9),
('Trung Bình',5.0,6.4),
('Yếu',0,4.9);

-- COMMENTS
INSERT INTO comments(student_id,teacher_id,semester_id,comment_text) VALUES
(1,11,1,'Tiếp tục phát huy.');


ALTER TABLE student_class
DROP FOREIGN KEY student_class_ibfk_1;

ALTER TABLE student_class
ADD CONSTRAINT student_class_ibfk_1
FOREIGN KEY (student_id)
REFERENCES students(student_id)
ON DELETE CASCADE;


ALTER TABLE teacher_assignments
DROP FOREIGN KEY teacher_assignments_ibfk_1;

ALTER TABLE teacher_assignments
ADD CONSTRAINT teacher_assignments_ibfk_1
FOREIGN KEY (teacher_id)
REFERENCES users(user_id)
ON DELETE CASCADE;
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
