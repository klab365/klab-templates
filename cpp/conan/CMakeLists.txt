cmake_minimum_required(VERSION 3.23)

set(CMAKE_EXPORT_COMPILE_COMMANDS ON)
enable_testing()

add_subdirectory(src/core)
add_subdirectory(src/adapters)
add_subdirectory(src/cmd/console)
