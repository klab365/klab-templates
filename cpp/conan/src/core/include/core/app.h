#pragma once

#include <string>

namespace myapp {

class App {
public:
    App();
    void run();
    std::string getVersion() const;

private:
    std::string version_;
};

} // namespace myapp
