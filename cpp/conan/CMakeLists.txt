cmake_minimum_required(VERSION 3.23)
project(myapp VERSION 1.0.0 LANGUAGES CXX)

add_subdirectory(src/core)
add_subdirectory(src/adapters)
add_subdirectory(src/cmd/console)
