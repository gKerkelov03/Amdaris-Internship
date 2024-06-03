import {
    AppBar,
    Box,
    Button,
    Container,
    CssBaseline,
    Grid,
    Paper,
    TextField,
    ThemeProvider,
    Toolbar,
    Typography,
    createTheme
} from '@mui/material';
import { styled } from '@mui/material/styles';
import React from 'react';
import { Link } from 'react-router-dom';

const theme = createTheme();

const HeroContent = styled('div')(({ theme }) => ({
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(8, 0, 6),
    backgroundImage: 'url(https://via.placeholder.com/1200x600)',
    backgroundSize: 'cover',
    backgroundPosition: 'center',
    color: '#fff',
    textAlign: 'center'
}));

const CardGrid = styled(Container)(({ theme }) => ({
    paddingTop: theme.spacing(8),
    paddingBottom: theme.spacing(8)
}));

const ServiceCard = styled(Paper)(() => ({
    height: '100%',
    display: 'flex',
    flexDirection: 'column'
}));

const CardContent = styled(Box)(({ theme }) => ({
    padding: theme.spacing(2)
}));

const Footer = styled('footer')(({ theme }) => ({
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(6)
}));

const LandingPage: React.FC = () => {
    return (
        <>
            <nav className="navigation">
                <Link to="/login">Login</Link>
                <Link to="/register">Register</Link>
            </nav>
            <ThemeProvider theme={theme}>
                <CssBaseline />
                <AppBar position="static">
                    <Toolbar>
                        <Typography variant="h6" color="inherit" noWrap>
                            SmartSalon
                        </Typography>
                    </Toolbar>
                </AppBar>
                <main>
                    <HeroContent>
                        <Container maxWidth="sm">
                            <Typography
                                component="h1"
                                variant="h2"
                                align="center"
                                gutterBottom
                            >
                                Book Your Salon Appointment Online
                            </Typography>
                            <Typography variant="h5" align="center" paragraph>
                                Conveniently book appointments at the best
                                salons in town with just a few clicks.
                            </Typography>
                        </Container>
                    </HeroContent>
                    <CardGrid maxWidth="md">
                        <Typography variant="h4" align="center" gutterBottom>
                            Our Services
                        </Typography>
                        <Grid container spacing={4}>
                            <Grid item key={1} xs={12} sm={6} md={4}>
                                <ServiceCard elevation={3}>
                                    <CardContent>
                                        <Typography
                                            gutterBottom
                                            variant="h5"
                                            component="h2"
                                        >
                                            Online Booking
                                        </Typography>
                                        <Typography>
                                            Easy and hassle-free online booking
                                            for various salon services.
                                        </Typography>
                                    </CardContent>
                                </ServiceCard>
                            </Grid>
                            <Grid item key={2} xs={12} sm={6} md={4}>
                                <ServiceCard elevation={3}>
                                    <CardContent>
                                        <Typography
                                            gutterBottom
                                            variant="h5"
                                            component="h2"
                                        >
                                            Top Salons
                                        </Typography>
                                        <Typography>
                                            Access to a curated list of
                                            top-rated salons in your area.
                                        </Typography>
                                    </CardContent>
                                </ServiceCard>
                            </Grid>
                            <Grid item key={3} xs={12} sm={6} md={4}>
                                <ServiceCard elevation={3}>
                                    <CardContent>
                                        <Typography
                                            gutterBottom
                                            variant="h5"
                                            component="h2"
                                        >
                                            Exclusive Deals
                                        </Typography>
                                        <Typography>
                                            Get exclusive deals and discounts on
                                            salon services.
                                        </Typography>
                                    </CardContent>
                                </ServiceCard>
                            </Grid>
                        </Grid>
                    </CardGrid>
                    <Container maxWidth="sm" component="section">
                        <Typography variant="h4" align="center" gutterBottom>
                            About Us
                        </Typography>
                        <Typography variant="h6" align="center" paragraph>
                            We are a leading platform dedicated to providing
                            seamless online booking solutions for salons. Our
                            mission is to make salon appointments more
                            accessible and convenient for everyone.
                        </Typography>
                    </Container>
                    <Container maxWidth="sm" component="section">
                        <Typography variant="h4" align="center" gutterBottom>
                            Contact Us
                        </Typography>

                        <form noValidate autoComplete="off">
                            <TextField
                                label="Your Name"
                                fullWidth
                                margin="normal"
                                variant="outlined"
                                required
                            />
                            <TextField
                                label="Your Email"
                                fullWidth
                                margin="normal"
                                variant="outlined"
                                required
                            />
                            <TextField
                                label="Your Message"
                                fullWidth
                                margin="normal"
                                variant="outlined"
                                required
                                multiline
                                rows={4}
                            />
                            <Box textAlign="center" m={2}>
                                <Button
                                    variant="contained"
                                    color="primary"
                                    type="submit"
                                >
                                    Send Message
                                </Button>
                            </Box>
                        </form>
                    </Container>
                </main>
                <Footer>
                    <Typography variant="h6" align="center" gutterBottom>
                        &copy; 2024 SmartSalon. All rights reserved.
                    </Typography>
                </Footer>
            </ThemeProvider>
        </>
    );
};

export default LandingPage;
