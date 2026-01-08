cmake_minimum_required(VERSION 3.23)
project(myapp VERSION 1.0.0 LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# Find dependencies managed by Conan
find_package(CONFIG)

# Core library
add_library(myapp_core
    src/core/app.cpp
)

target_include_directories(myapp_core PUBLIC
    $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/src>
    $<INSTALL_INTERFACE:include>
)

# Main executable
add_executable(myapp
    src/cmd/main.cpp
)

target_link_libraries(myapp PRIVATE myapp_core)
