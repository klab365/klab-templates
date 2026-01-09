FROM debian:13.2-slim AS ci

ARG UID=1000
RUN <<EOF
    set -eu

    apt update
    apt install -y zsh git curl sudo pkg-config libssl-dev python3 python3-pip python3-venv
    apt install -y build-essential cmake ninja-build clang-format clang-tidy gcovr

    # create a user dev with the UID and the sudo group
    useradd -m -u $UID -G sudo dev
    echo "dev ALL=(ALL) NOPASSWD:ALL" >> /etc/sudoers

    # install cpp tools

    # Create .conan2 directory for dev user and set permissions
    mkdir -p /home/dev/.conan2
    chown -R dev:dev /home/dev/.conan2

    # cleanup
    apt-get clean
    rm -rf /var/lib/apt/lists/*
EOF

FROM ci AS dev

RUN <<EOF
    set -eu
    apt update
    apt install -y zsh git curl sudo pkg-config libssl-dev

    curl --proto '=https' --tlsv1.2 -sSf https://just.systems/install.sh | bash -s -- --to /usr/local/bin

    # Setup shell for dev user
    chsh -s /bin/zsh dev
    su - dev -c 'sh -c "$(curl -fsSL https://raw.github.com/ohmyzsh/ohmyzsh/master/tools/install.sh)" "" --unattended'
    su - dev -c 'git clone https://github.com/zsh-users/zsh-autosuggestions ${ZSH_CUSTOM:-~/.oh-my-zsh/custom}/plugins/zsh-autosuggestions'
    su - dev -c 'sed -i "s/plugins=(git)/plugins=(git zsh-autosuggestions)/" ~/.zshrc'
    curl -sS https://starship.rs/install.sh | sh -s -- --yes
    su - dev -c 'echo "eval \"\$(starship init zsh)\"" >> ~/.zshrc'

    # Create cargo directory for dev user
    mkdir -p /home/dev/.cargo
    chown -R dev:dev /home/dev/.cargo
    su - dev -c 'echo "export CARGO_HOME=/home/dev/.cargo" >> ~/.zshrc'

    # cleanup
    apt-get clean
    rm -rf /var/lib/apt/lists/*
EOF


